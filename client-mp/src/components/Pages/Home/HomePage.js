import { Grid } from "@material-ui/core";
import React from "react";
import { Col, Row } from "reactstrap";
import { useAppContext } from "../../../providers/ApplicationProvider";
import NoLogin from "../NoLogin/NoLogin";
import ListUsers from "./ListUsers";
import Timetable from "./Timetable/Timetable";

const HomePage = () => {
  const [{ accessToken, userId }] = useAppContext();

  return accessToken === null ? (
    <NoLogin />
  ) : (
    <Grid container spacing={2}>
      <Grid item md={9}>
        <Timetable userId={userId} />
      </Grid>
      <Grid item md={3}>
        <ListUsers />
      </Grid>
    </Grid>
  );
};

export default HomePage;
