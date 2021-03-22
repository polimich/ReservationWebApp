import { Grid } from "@material-ui/core";
import React from "react";
import { useParams } from "react-router-dom/cjs/react-router-dom.min";
import UserTimetable from "./Timetable";

//*Komponenta zobrazující rozvhr jiných než přihlášených uživatelů podle id
const UserInfoPage = () => {
  var { userId } = useParams();
  if (userId === undefined) userId = "";
  return (
    <>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <UserTimetable />
        </Grid>
      </Grid>
    </>
  );
};

export default UserInfoPage;
