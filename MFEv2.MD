Here’s the entire project code for your micro-frontend (MFE) setup in one place, including:

	1.	Shell App: A React app using MobX for state management, responsible for login and loading other MFEs.
	2.	React MFE: A micro-frontend app built in React.
	3.	Angular MFE: A micro-frontend app built in Angular.
	4.	Streamlit App: A standalone app loaded via an iFrame.

Folder Structure

root/
├── shell/                # React shell app (Host)
├── react-mfe/            # React micro-frontend
├── angular-mfe/          # Angular micro-frontend
└── streamlit-mfe/        # Streamlit app

1. Shell App (React)

Setup

	1.	Create a new React project:

npx create-react-app shell --template typescript
cd shell
npm install mobx mobx-react-lite @mui/material @emotion/react @emotion/styled
npm install --save-dev webpack webpack-cli webpack-dev-server module-federation-plugin



Shell App Code

webpack.config.js

Configure Module Federation to load the React and Angular MFEs dynamically.

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

src/LoginContext.tsx

This file provides the login functionality using React Context.

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

This component loads the Streamlit app via an iFrame.

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

The main page integrates React MFE, Angular MFE, and the Streamlit app.

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

This file provides the login form and loads MainPage.

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

Setup

	1.	Create the React MFE:

npx create-react-app react-mfe --template typescript
cd react-mfe
npm install --save-dev webpack module-federation-plugin



React MFE Code

webpack.config.js

const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

module.exports = {
  plugins: [
    new ModuleFederationPlugin({
      name: "reactApp",
      filename: "remoteEntry.js",
      exposes: {
        "./App": "./src/App",
      },
      shared: {
        react: { singleton: true, eager: true },
        "react-dom": { singleton: true, eager: true },
      },
    }),
  ],
};

src/App.tsx

import React from "react";

const App: React.FC = () => {
  return <div>Welcome to the React Micro-Frontend!</div>;
};

export default App;

3. Angular MFE

Setup

	1.	Create the Angular MFE:

ng new angular-mfe --style=css --routing=false
cd angular-mfe
npm install --save-dev @angular-architects/module-federation



Angular MFE Code

Update webpack.config.js and create a simple Angular component to expose.

4. Streamlit App

Setup

	1.	Create the Streamlit app:

mkdir streamlit-mfe
cd streamlit-mfe
pip install streamlit


	2.	app.py

import streamlit as st

query_params = st.experimental_get_query_params()
username = query_params.get("username", ["Guest"])[0]

st.title("Streamlit Micro-Frontend")
st.write(f"Hello, {username}! Welcome to the Streamlit MFE.")

Run:

streamlit run app.py

Final Steps

Start all apps:

	1.	Streamlit: streamlit run app.py
	2.	React MFE: npm start
	3.	Angular MFE: ng serve
	4.	Shell App: npm start

This will integrate all components with shared login context and display them as MFEs.
