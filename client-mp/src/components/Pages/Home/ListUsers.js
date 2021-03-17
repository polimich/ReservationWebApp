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
require("datejs");

const ListUsers = () => {
  const [hours, setHours] = useState([]);
  //const start = Date.today().toString("yyyy-MM-ddTHH:mm:ss");
  const start = getToday();
  const [{ accessToken, role, userId }] = useAppContext();
  const [personName, setPersonName] = useState();
  const [renderedList, setRenderedList] = useState();

  useEffect(() => {
    var currentPerson = "";
    api.get(`/Hour/GetUsersWeek/${userId}/${start}`).then((res) => {
      setHours(res.data);
    });
    if (role === "Trener") {
      setRenderedList(
        hours.map(({ person }) => {
          if (currentPerson !== person) {
            currentPerson = person;
            api.get(`/Account/${person}`).then((response) => {
              setPersonName(
                response.data.firstName + " " + response.data.lastName
              );
            });
            return (
              <TableRow key={person}>
                <TableCell component={Link} to={`/userInfo/${person}`}>
                  {personName}
                </TableCell>
              </TableRow>
            );
          }
        })
      );
    } else {
      setRenderedList(
        hours.map(({ requester }) => {
          if (currentPerson !== requester) {
            currentPerson = requester;
            api.get(`/Account/${requester}`).then((response) => {
              setPersonName(
                response.data.firstName + " " + response.data.lastName
              );
            });
            return (
              <TableRow key={requester}>
                <TableCell component={Link} to={`/userInfo/${requester}`}>
                  {personName}
                </TableCell>
              </TableRow>
            );
          }
        })
      );
    }
  }, [hours, role, accessToken, start, userId]);
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
        <TableBody>{renderedList}</TableBody>
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
