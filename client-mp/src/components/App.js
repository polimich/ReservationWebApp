import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Menu from "./Menu/Menu";
import HomePage from "./Pages/Home/HomePage";
import LoginPage from "./Pages/Login/LoginPage";
import RegisterPage from "./Pages/Register/RegisterPage";
import SearchPage from "./Pages/Search/SearchPage";
import UserSettingsPage from "./Pages/UserSettings/UserSettingsPage";
import UserInfoPage from "./Pages/UserInfo/UserInfoPage";
import { AppProvider, useAppContext } from "../providers/ApplicationProvider";
import NoLogin from "./Pages/NoLogin/NoLogin";
import TestMaterialUIFormik from "./TestMaterialUIFormik";
import { Container, Grid } from "@material-ui/core";
const App = () => {
  return (
    <AppProvider>
      <Router>
        <Grid container>
          <Grid item xs={12}>
            <Menu />
          </Grid>
          <Grid item xs={12}>
            <Container maxWidth="xl">
              <Switch>
                <Route exact path="/" component={NoLogin} />
                <Route exact path="/home" component={HomePage} />
                <Route exact path="/login" component={LoginPage} />
                <Route exact path="/register" component={RegisterPage} />
                <Route exact path="/search" component={SearchPage} />
                <Route
                  exact
                  path="/userSettings"
                  component={UserSettingsPage}
                />
                <Route exact path="/userInfo" component={UserInfoPage} />
                <Route exact path="/test" component={TestMaterialUIFormik} />
              </Switch>
            </Container>
          </Grid>
        </Grid>
      </Router>
    </AppProvider>
  );
};

export default App;
