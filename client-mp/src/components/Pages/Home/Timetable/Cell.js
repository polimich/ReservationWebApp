import { Form, Formik } from "formik";
import React from "react";
import { useEffect, useState } from "react/cjs/react.development";
import * as Yup from "yup";
import api from "../../../../api/api";
import { useAppContext } from "../../../../providers/ApplicationProvider";
import {
  Card,
  CardContent,
  Dialog,
  DialogContent,
  DialogTitle,
  Grid,
  TableCell,
  Typography,
} from "@material-ui/core";
import Textfield from "../../../FormUI/Textfield";
import Select from "../../../FormUI/Select";
import DateTimePicker from "../../../FormUI/DateTimePicker";
import Checkbox from "../../../FormUI/Checkbox";
import Button from "../../../FormUI/Button";

const Cell = ({ date, userId }) => {
  const [name, setName] = useState();
  const [personName, setPersonName] = useState();
  const [personId, setPersonId] = useState();
  const [zaci, setZaci] = useState([]);
  const [{ accessToken, role, whatITeach }] = useAppContext();
  const [predmet, setPredmet] = useState();
  let currentPerson = "";
  //Modal věci
  const [openDialog, setOpenDialog] = useState(false);
  const handleClickOpen = () => {
    name === undefined ? setOpenDialog(true) : setOpenDialog(false);
  };
  const handleClose = () => {
    setOpenDialog(false);
  };
  const INITIAL_FORM_STATE = {
    name: whatITeach,
    person: "",
    start: new Date(date),
    end: new Date(),
    oneTime: false,
    requester: userId,
  };
  const FORM_VALIDATION = Yup.object().shape({
    email: Yup.string().email("Invalid email").required("Email required"),
    name: Yup.string().required("Choose type of hour"),
    person: Yup.string().required("Choose student"),
    requester: Yup.string().required("Choose trainer"),
    start: Yup.date().required("Choose starting time"),
    end: Yup.date().required("Choose starting end"),
    oneTime: Yup.boolean().required(),
  });

  useEffect(() => {
    if (userId !== null) {
      if (role === "Trener") {
        api
          .get(`/Hour/${userId}/${date}`, {
            headers: {
              Authorization: "Bearer" + accessToken,
              "Content-Type": "application/json",
            },
          })
          .then((response) => {
            setPersonId(response.data.person);
          });
        api
          .get(`/Hour/GetAllUsersHours/${userId}`, {
            headers: {
              Authorization: "Bearer" + accessToken,
              "Content-Type": "application/json",
            },
          })
          .then((response) => {
            response.data.map(({ person }) => {
              if (currentPerson !== person) {
                currentPerson = person;
                api
                  .get(`/Account/${person}`, {
                    headers: {
                      Authorization: "Bearer" + accessToken,
                      "Content-Type": "application/json",
                    },
                  })
                  .then((response) => {
                    setZaci((arr) => [
                      ...arr,
                      {
                        id: person,
                        name:
                          response.data.firstName +
                          " " +
                          response.data.lastName,
                      },
                    ]);
                  });
              }
            });
          });
        if (personId !== undefined) {
          api
            .get(`/Account/${personId}`, {
              headers: {
                headers: {
                  Authorization: "Bearer" + accessToken,
                  "Content-Type": "application/json",
                },
              },
            })
            .then((response) => {
              setName(response.data.lastName);
            });
        }
      } else {
        api
          .get(`/Hour/${userId}/${date}`, {
            headers: {
              Authorization: "Bearer" + accessToken,
              "Content-Type": "application/json",
            },
          })
          .then((response) => {
            setName(response.data.name);
            setPersonId(response.data.requester);
          });
        if (personId !== undefined) {
          api
            .get(`/Account/${personId}`, {
              headers: {
                headers: {
                  Authorization: "Bearer" + accessToken,
                  "Content-Type": "application/json",
                },
              },
            })
            .then((response) => {
              setPersonName(response.data.lastName);
            });
        }
      }
    }
    console.log(zaci);
  }, []);

  return (
    <>
      <TableCell onClick={handleClickOpen}>
        <Card>
          <CardContent>
            <Typography variant="h6">
              {name === undefined ? " " : name}
            </Typography>
            <Typography>{name === undefined ? " " : personName}</Typography>
          </CardContent>
        </Card>
      </TableCell>
      <Dialog open={openDialog} onClose={handleClose}>
        <DialogTitle id="add-hour-form">{name}</DialogTitle>
        <DialogContent>
          <Formik
            initialValues={{ ...INITIAL_FORM_STATE }}
            validationSchema={FORM_VALIDATION}
            onSubmit={(values) => {
              console.log(values);
            }}
          >
            <Form>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <Typography>Example form</Typography>
                </Grid>
                <Grid item xs={12}>
                  <Select name="person" label="Students name" options={zaci} />
                </Grid>
                <Grid item xs={12}>
                  <Textfield name="email" label="Email" />
                </Grid>
                <Grid item xs={12}>
                  <DateTimePicker name="start" label="Hour start" />
                </Grid>
                <Grid item xs={12}>
                  <Checkbox
                    name="oneTime"
                    legend="One time hour"
                    label="I want this hour to be one time"
                  />
                </Grid>
                <Grid item xs={12}>
                  <Button>Submit</Button>
                </Grid>
              </Grid>
            </Form>
          </Formik>
        </DialogContent>
      </Dialog>
    </>
  );
};
export default Cell;
