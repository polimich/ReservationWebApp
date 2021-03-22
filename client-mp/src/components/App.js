import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Menu from "./Menu/Menu";
import HomePage from "./Pages/Home/HomePage";
import LoginPage from "./Pages/Login/LoginPage";
import RegisterPage from "./Pages/Register/RegisterPage";
import SearchPage from "./Pages/Search/SearchPage";
import UserSettingsPage from "./Pages/UserSettings/UserSettingsPage";
import UserInfoPage from "./Pages/UserInfo/UserInfoPage";
import { AppProvider } from "../providers/ApplicationProvider";
import NoLogin from "./Pages/NoLogin/NoLogin";
import { Container, Grid } from "@material-ui/core";

//* Hlavní komponenta každé react aplikace
//* Je zde udělaná logika routování
//* zaveden Container pro celou aplikaci kvůli reponzivitě
const App = () => {
  return (
    <AppProvider>
      <Router>
        <Grid container>
          <Grid item xs={12}>
            <Menu />
          </Grid>
          <Grid item xs={12}>
            <Container>
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
                <Route
                  exact
                  path="/userInfo/:userID?"
                  component={UserInfoPage}
                />
              </Switch>
            </Container>
          </Grid>
        </Grid>
      </Router>
    </AppProvider>
  );
};

export default App;
