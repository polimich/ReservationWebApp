import { Button, Container, Grid, Typography } from "@material-ui/core";
import React from "react";
import { Link } from "react-router-dom/cjs/react-router-dom.min";

//* Komponenta zobrazující se pokud není přihlášen žádný uživatel, vyzívá k registraci nebo přihlášení
const NoLogin = () => {
  return (
    <Container>
      <Grid container alignItems="center" alignContent="center" spacing={2}>
        <Grid item xs={12}></Grid>
        <Grid item xs={12} alignContent="center">
          <Typography fullWidth align="center" variant="h4">
            Please Login or register to use the app!
          </Typography>
        </Grid>
        <Grid item xs={12}></Grid>
        <Grid item xs={6}>
          <Button
            fullWidth
            variant="outlined"
            size="large"
            component={Link}
            to="/login"
          >
            Login
          </Button>
        </Grid>
        <Grid item xs={6}>
          <Button
            fullWidth
            variant="outlined"
            size="large"
            component={Link}
            to="/register"
          >
            Register
          </Button>
        </Grid>
      </Grid>
    </Container>
  );
};

export default NoLogin;
