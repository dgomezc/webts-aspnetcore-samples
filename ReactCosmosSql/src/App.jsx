﻿import React from "react";
import { Switch, Route } from "react-router-dom";
import "./App.css";
import NavBar from "./components/NavBar";
import Footer from "./components/Footer";

import Blank from "./components/Blank/Blank";

import Grid from "./components/Grid/Grid";

import List from "./components/List/List";

import Master_Detail from "./components/Master_Detail/Master_Detail";

//TODO Web Template Studio: Add routes for your new pages here.
const App = () => {
    return (
      <React.Fragment>
        <NavBar />
        <Switch>
          <Route exact path = "/" component = { Blank } />
          <Route path = "/Grid" component = { Grid } />
          <Route path = "/List" component = { List } />
          <Route path = "/Master_Detail" component = { Master_Detail } />
        </Switch>
        <Footer />
      </React.Fragment>
    );
}

export default App;
