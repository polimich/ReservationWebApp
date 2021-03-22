import { Grid, Typography } from "@material-ui/core";
import React from "react";
import { useAppContext } from "../../../providers/ApplicationProvider";
import NoLogin from "../NoLogin/NoLogin";
import ListUsers from "./ListUsers";
import Timetable from "./Timetable/Timetable";

//* Komponenta hlavní stránky, skládá se z rozvrhu a listu uživatelů
const HomePage = () => {
  const [{ accessToken, userId }] = useAppContext();

  return accessToken === null ? (
    <NoLogin />
  ) : (
    <Grid container spacing={2}>
      <Grid item xs={12}>
        <Typography variant="h6">Timetable:</Typography>
      </Grid>
      <Grid item xs={12}>
        <Timetable userId={userId} />
      </Grid>
      <Grid item xs={12}>
        <ListUsers />
      </Grid>
    </Grid>
  );
};

export default HomePage;
