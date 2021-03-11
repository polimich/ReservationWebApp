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

const ListUsers = () => {
  const [hours, setHours] = useState([]);
  const start = getToday();
  const [{ accessToken, role, userId }] = useAppContext();
  const [personName, setPersonName] = useState();
  let currentPerson = "";
  useEffect(() => {
    api
      .get(`/Hour/GetUsersWeek/${userId}/${start}`, {
        headers: {
          headers: {
            Authorization: "Bearer" + accessToken,
            "Content-Type": "application/json",
          },
        },
      })
      .then((res) => {
        console.log(res.data);
        setHours(res.data);
      });
  }, []);

  if (role === "Trener") {
    return (
      <Paper elevation={2}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Students:</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {hours.map(({ person }) => {
              if (currentPerson !== person) {
                currentPerson = person;
                api.get(`/Account/${person}`).then((response) => {
                  setPersonName(
                    response.data.firstName + " " + response.data.lastName
                  );
                });
                return (
                  <TableRow key={person}>
                    <TableCell component={Link} to="/">
                      {personName}
                    </TableCell>
                  </TableRow>
                );
              } else return null;
            })}
          </TableBody>
        </Table>
      </Paper>
    );
  } else {
    return (
      <>
        <Paper elevation={2}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Trainers:</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {hours.map(({ requester }) => {
                if (currentPerson !== requester) {
                  currentPerson = requester;
                  api.get(`/Account/${requester}`).then((response) => {
                    setPersonName(
                      response.data.firstName + " " + response.data.lastName
                    );
                  });
                  return (
                    <TableRow key={requester}>
                      <TableCell component={Link} to="/">
                        {personName}
                      </TableCell>
                    </TableRow>
                  );
                } else return null;
              })}
            </TableBody>
          </Table>
        </Paper>
      </>
    );
  }
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
