Here’s the full and final code for your micro-frontend (MFE) setup, including a React shell app, React and Angular MFEs, and a Streamlit app loaded via an iFrame. The shell app also includes login functionality with shared login context passed to all apps.

Folder Structure

root/
├── shell/                # React shell app (Host)
├── react-mfe/            # React micro-frontend
├── angular-mfe/          # Angular micro-frontend
└── streamlit-mfe/        # Streamlit micro-frontend

1. Shell App (React)

Setup

	1.	Create a new React project for the shell:

npx create-react-app shell --template typescript
cd shell
npm install mobx mobx-react-lite @mui/material @emotion/react @emotion/styled
npm install --save-dev webpack webpack-cli webpack-dev-server module-federation-plugin


	2.	Configure Module Federation in webpack.config.js:

const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

module.exports = {
  plugins: [
    new ModuleFederationPlugin({
      name: "shell",
      remotes: {
        reactApp: "reactApp@http://localhost:3001/remoteEntry.js",
        angularApp: "angularApp@http://localhost:4200/remoteEntry.js",
      },
      shared: {
        react: { singleton: true, eager: true },
        "react-dom": { singleton: true, eager: true },
      },
    }),
  ],
};


	3.	Add the following files:

src/LoginContext.tsx

Provide login functionality using React Context.

import React, { createContext, useState, useContext } from "react";

interface LoginContextType {
  isLoggedIn: boolean;
  username: string;
  login: (username: string) => void;
  logout: () => void;
}

const LoginContext = createContext<LoginContextType | undefined>(undefined);

export const LoginProvider: React.FC = ({ children }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [username, setUsername] = useState("");

  const login = (username: string) => {
    setIsLoggedIn(true);
    setUsername(username);
  };

  const logout = () => {
    setIsLoggedIn(false);
    setUsername("");
  };

  return (
    <LoginContext.Provider value={{ isLoggedIn, username, login, logout }}>
      {children}
    </LoginContext.Provider>
  );
};

export const useLoginContext = (): LoginContextType => {
  const context = useContext(LoginContext);
  if (!context) {
    throw new Error("useLoginContext must be used within LoginProvider");
  }
  return context;
};

src/components/StreamlitApp.tsx

Load the Streamlit app in an iFrame.

import React from "react";

const StreamlitApp: React.FC<{ username: string }> = ({ username }) => {
  const streamlitUrl = `http://localhost:8501?username=${username}`;

  return (
    <div style={{ height: "600px", border: "1px solid #ccc" }}>
      <iframe
        src={streamlitUrl}
        width="100%"
        height="100%"
        frameBorder="0"
        title="Streamlit App"
      />
    </div>
  );
};

export default StreamlitApp;

src/pages/MainPage.tsx

Integrate all MFEs and the Streamlit app into the shell.

import React, { Suspense } from "react";
import { useLoginContext } from "../LoginContext";
import StreamlitApp from "../components/StreamlitApp";

const ReactMFE = React.lazy(() => import("reactApp/App"));
const AngularMFE = React.lazy(() => import("angularApp/App"));

const MainPage: React.FC = () => {
  const { isLoggedIn, username } = useLoginContext();

  return (
    <div>
      <h1>Shell App</h1>
      {isLoggedIn ? (
        <>
          <div>
            <h2>React Micro-Frontend</h2>
            <Suspense fallback={<div>Loading React MFE...</div>}>
              <ReactMFE />
            </Suspense>
          </div>
          <div>
            <h2>Angular Micro-Frontend</h2>
            <Suspense fallback={<div>Loading Angular MFE...</div>}>
              <AngularMFE />
            </Suspense>
          </div>
          <div>
            <h2>Streamlit Micro-Frontend</h2>
            <StreamlitApp username={username} />
          </div>
        </>
      ) : (
        <p>Please log in to access the applications.</p>
      )}
    </div>
  );
};

export default MainPage;

src/App.tsx

Add a login form and integrate MainPage.

import React, { useState } from "react";
import { useLoginContext } from "./LoginContext";
import MainPage from "./pages/MainPage";

const App: React.FC = () => {
  const { isLoggedIn, login } = useLoginContext();
  const [usernameInput, setUsernameInput] = useState("");

  const handleLogin = () => {
    if (usernameInput.trim()) {
      login(usernameInput);
    }
  };

  return (
    <div>
      {!isLoggedIn ? (
        <div>
          <h1>Login</h1>
          <input
            type="text"
            placeholder="Enter username"
            value={usernameInput}
            onChange={(e) => setUsernameInput(e.target.value)}
          />
          <button onClick={handleLogin}>Login</button>
        </div>
      ) : (
        <MainPage />
      )}
    </div>
  );
};

export default App;

2. React MFE

Follow the instructions from the React MFE Setup in the previous implementation.

3. Angular MFE

Follow the instructions from the Angular MFE Setup in the previous implementation.

4. Streamlit App

Setup

	1.	Create the Streamlit app:

mkdir streamlit-mfe
cd streamlit-mfe
pip install streamlit


	2.	Create app.py:

import streamlit as st

query_params = st.experimental_get_query_params()
username = query_params.get("username", ["Guest"])[0]

st.title("Streamlit Micro-Frontend")
st.write(f"Hello, {username}! Welcome to the Streamlit MFE.")


	3.	Run the app:

streamlit run app.py



Testing the Setup

	1.	Start Streamlit App:

cd streamlit-mfe
streamlit run app.py


	2.	Start React MFE:

cd react-mfe
npm start


	3.	Start Angular MFE:

cd angular-mfe
ng serve


	4.	Start Shell App:

cd shell
npm start



Behavior

	1.	Login: The user logs in through the shell app.
	2.	React and Angular MFEs: Loaded dynamically via Module Federation.
	3.	Streamlit App: Displayed in an iFrame, passing the login username as a query parameter.
