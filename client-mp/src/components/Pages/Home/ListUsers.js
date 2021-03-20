import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@material-ui/core";
import React from "react";
import { Link } from "react-router-dom";
import { useEffect, useState } from "react/cjs/react.development";
import api from "../../../api/api";
import { useAppContext } from "../../../providers/ApplicationProvider";
import { GetStudents, GetTrainers } from "./Timetable/Functions";
require("datejs");

const ListUsers = () => {
  //const start = Date.today().toString("yyyy-MM-ddTHH:mm:ss");
  const start = getToday();
  const [{ accessToken, role, userId }] = useAppContext();
  const [personName, setPersonName] = useState();
  const [personArr, setPersonArr] = useState();
  const [isLoading, setLoading] = useState(true);
  const [renderedList, setRenderedList] = useState();
  var currentPerson = "";

  useEffect(() => {
    if (isLoading) {
      setPersonArr(
        role === "Trener" ? GetStudents(userId) : GetTrainers(userId)
      );
      personArr === undefined ? setLoading(true) : setLoading(false);
    }
    if (isLoading === false) {
      setRenderedList(
        personArr.map(({ name, id }) => {
          return (
            <TableRow key={id}>
              <TableCell component={Link} to={`/userInfo/${id}`}>
                {name}
              </TableCell>
            </TableRow>
          );
        })
      );
    }
  }, [personArr, role, userId, isLoading]);
  return (
    <Paper elevation={2}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>
              {role === "Trener" ? "Students:" : "Teachers:"}
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>{isLoading ? <div>Loading</div> : renderedList}</TableBody>
      </Table>
    </Paper>
  );
};

const getToday = (separator = "-") => {
  let today = new Date();
  let day = today.getDate();
  let month = today.getMonth() + 1;
  let year = today.getFullYear();

  return `${year}${separator}${
    month < 10 ? `0${month}` : `${month}`
  }${separator}${day}T00:00:00`;
};

export default ListUsers;
