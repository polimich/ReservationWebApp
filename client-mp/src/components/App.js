import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Menu from "./Menu/Menu";
import HomePage from "./Pages/Home/HomePage";
import LoginPage from "./Pages/Login/LoginPage";
import RegisterPage from "./Pages/Register/RegisterPage";
import SearchPage from "./Pages/Search/SearchPage";
import UserSettingsPage from "./Pages/UserSettings/UserSettingsPage";
import UserInfoPage from "./Pages/UserInfo/UserInfoPage";

const App = () => {
  return (
    <Router>
      <Menu />
      <Switch>
        <Route exact path="/home" component={HomePage} />
        <Route exact path="/login" component={LoginPage} />
        <Route exact path="/register" component={RegisterPage} />
        <Route exact path="/search" component={SearchPage} />
        <Route exact path="/userSettings" component={UserSettingsPage} />
        <Route exact path="/userInfo" component={UserInfoPage} />
      </Switch>
    </Router>
  );
};

export default App;
