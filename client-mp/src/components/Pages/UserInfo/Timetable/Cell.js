import { Form, Formik } from "formik";
import React from "react";
import { useEffect, useState } from "react/cjs/react.development";
import * as Yup from "yup";
import api from "../../../../api/api";
import { useAppContext } from "../../../../providers/ApplicationProvider";
import {
  Button,
  Card,
  CardContent,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Grid,
  TableCell,
  Typography,
} from "@material-ui/core";
import AddIcon from "@material-ui/icons/Add";
require("datejs");

//*TODO rerender after edit, cely rozvrh

const Cell = ({ date, userId }) => {
  const [name, setName] = useState();
  const [personName, setPersonName] = useState();
  const [personId, setPersonId] = useState();
  const [requesterId, setRequesterId] = useState();
  const [requesterName, setRequesterName] = useState();
  const [{ whatITeach }] = useAppContext();
  const [role, setRole] = useState();

  useEffect(() => {
    //user musi byt prihlasen

    if (userId !== null) {
      api.get(`/Account/GetUserRole/${userId}`).then((response) => {
        setRole(response.data);
      });
      //Trener
      if (role === "Trener") {
        //Najde jestli dany trener (userId) ma v case date hodinu a zapiše zakovo Id
        api.get(`/Hour/${userId}/${date}`).then((response) => {
          setPersonId(response.data.person);
        });
        //Pokud nasel hodinu, vezme ZakovoId (PersonId) a zjisti jeho jmeno
        if (personId !== undefined) {
          api.get(`/Account/${personId}`).then((response) => {
            setPersonName(response.data.lastName);
          });
        }
        //Student
      } else {
        //Najde jestli dany zak (userId) ma v case date hodinu a zapíše zakovo Id
        api.get(`/Hour/${userId}/${date}`).then((response) => {
          setName(response.data.name);
          setRequesterId(response.data.requester);
        });
        if (requesterId !== undefined) {
          api.get(`/Account/${requesterId}`).then((response) => {
            setRequesterName(response.data.lastName);
          });
        }
      }
    }
  }, [personId, requesterId, date, role, userId]);

  return (
    <>
      <TableCell align="center">
        <Card
          elevation={
            personName === undefined &&
            name === undefined &&
            requesterName === undefined
              ? 0
              : 2
          }
        >
          <CardContent>
            <Typography variant="h6">
              {role === "Trener" ? personName : name}
            </Typography>
            <Typography>{role === "Trener" ? name : requesterName}</Typography>
          </CardContent>
        </Card>
      </TableCell>
    </>
  );
};
export default Cell;
