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
import Select from "../../../FormUI/Select";
import DateTimePicker from "../../../FormUI/DateTimePicker";
import Checkbox from "../../../FormUI/Checkbox";
import SubmitButton from "../../../FormUI/Button";
import AddIcon from "@material-ui/icons/Add";
import { GetStudents } from "./Functions";
import { Alert } from "@material-ui/lab";
import axios from "axios";
require("datejs");

//*TODO rerender after edit, cely rozvrh

const Cell = ({ date, userId }) => {
  const [name, setName] = useState();
  const [personName, setPersonName] = useState();
  const [personId, setPersonId] = useState();
  const [requesterId, setRequesterId] = useState();
  const [requesterName, setRequesterName] = useState();
  const [AddDialogVisibility, setAddDialogVisibility] = useState(false);
  const [EditDialogVisibility, setEditDialogVisibility] = useState(false);
  const [zaci, setZaci] = useState([]);
  const [hour, setHour] = useState();
  const [{ accessToken, role, whatITeach }] = useAppContext();
  const endDate = Date.parse(date).addHours(1);

  //Add Dialog Things
  const [openAddDialog, setOpenAddDialog] = useState(false);
  const [openEditDialog, setOpenEditDialog] = useState(false);

  const handleOpenDialogs = () => {
    if (role === "Trener" && AddDialogVisibility) {
      setOpenAddDialog(true);
    }
    if (role === "Trener" && EditDialogVisibility) {
      setOpenEditDialog(true);
    }
  };
  const handleCloseDialogs = () => {
    setOpenAddDialog(false);
    setOpenEditDialog(false);
  };

  //Add form values
  const INITIAL_ADD_FORM_STATE = {
    name: whatITeach,
    person: "",
    start: Date.parse(date).addHours(1).toISOString(),
    end: Date.parse(endDate).addHours(1).toISOString(),
    oneTime: false,
    requester: userId,
  };
  const ADD_FORM_VALIDATION = Yup.object().shape({
    person: Yup.string().required("Choose student"),

    oneTime: Yup.boolean(),
  });
  //Edit form values

  const INITIAL_EDIT_FORM_STATE = {
    nameEdit: hour !== undefined ? hour.name : "",
    personEdit: hour !== undefined ? hour.person : "",
    startEdit: hour !== undefined ? hour.start : "",
    endEdit: hour !== undefined ? hour.end : "",
    oneTimeEdit: hour !== undefined ? hour.isOneTime : "",
    requesterEdit: userId,
  };
  const EDIT_FORM_VALIDATION = Yup.object().shape({
    personEdit: Yup.string().required("Choose student"),
    startEdit: Yup.string().required("Choose when the hour starts"),
    oneTimeEdit: Yup.boolean(),
  });

  useEffect(() => {
    //user musi byt prihlasen
    if (userId !== null) {
      //Trener
      if (role === "Trener") {
        //Najde jestli dany trener (userId) ma v case date hodinu a zapiše zakovo Id
        api
          .get(`/Hour/${userId}/${date}`, {
            headers: { Authorization: "Bearer " + accessToken },
          })
          .then((response) => {
            setPersonId(response.data.person);
            setHour(response.data);
          });
        //Zjisti vsechny hodiny trenera a vytvori seznam trenerovych zaku
        setZaci(GetStudents(userId));
        //Pokud nasel hodinu, vezme ZakovoId (PersonId) a zjisti jeho jmeno
        if (personId !== undefined) {
          api
            .get(`/Account/${personId}`, {
              headers: { Authorization: "Bearer " + accessToken },
            })
            .then((response) => {
              setPersonName(response.data.lastName);
              setAddDialogVisibility(false);
              setEditDialogVisibility(true);
            });
        }
        if (personId === undefined) {
          setPersonName(<AddIcon />);
          setAddDialogVisibility(true);
          setEditDialogVisibility(false);
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
      <TableCell align="center" onClick={handleOpenDialogs}>
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
            <Typography>{role === "Trener" ? " " : requesterName}</Typography>
          </CardContent>
        </Card>
      </TableCell>
      <Dialog open={openAddDialog} onClose={handleCloseDialogs}>
        <DialogTitle id="add-hour-form">
          {"Hour: " +
            Date.parse(date).toString("d MMMM yyyy HH:mm") +
            "-" +
            Date.parse(endDate).toString("HH:mm")}
        </DialogTitle>
        <DialogContent>
          <Formik
            initialValues={{ ...INITIAL_ADD_FORM_STATE }}
            validationSchema={ADD_FORM_VALIDATION}
            onSubmit={async (values, { setSubmitting }) => {
              setSubmitting(true);
              api
                .post("/Hour", {
                  name: values.name,
                  person: values.person,
                  start: values.start,
                  end: values.end,
                  requester: values.requester,
                  isOneTime: values.isOneTime,
                })
                .then((response) => {
                  setPersonId("");
                });
              setSubmitting(false);
              handleCloseDialogs();
            }}
          >
            <Form>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <Select name="person" label="Students name" options={zaci} />
                </Grid>

                <Grid item xs={12}>
                  <Checkbox
                    name="oneTime"
                    legend="One time hour"
                    label="I want this hour to be one time"
                  />
                </Grid>
              </Grid>
              <DialogActions>
                <SubmitButton>Add Hour</SubmitButton>
              </DialogActions>
            </Form>
          </Formik>
        </DialogContent>
      </Dialog>
      <Dialog open={openEditDialog} onClose={handleCloseDialogs}>
        <DialogTitle id="Edit-dialog">Edit Dialog</DialogTitle>
        <DialogContent>
          <Formik
            initialValues={{ ...INITIAL_EDIT_FORM_STATE }}
            validationSchema={EDIT_FORM_VALIDATION}
            onSubmit={(values, { setSubmitting }) => {
              setSubmitting(true);
              api
                .put("/Hour", {
                  id: hour.id,
                  name: values.nameEdit,
                  person: values.personEdit,
                  start: Date.parse(values.startEdit).addHours(1).toISOString(),
                  end: Date.parse(values.startEdit).addHours(2).toISOString(),
                  requester: values.requesterEdit,
                  isOneTime: values.isOneTimeEdit,
                })
                .then((response) => {
                  setPersonId("");
                });
              setSubmitting(false);
              handleCloseDialogs();
              setSubmitting(true);
            }}
          >
            <Form>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <Select
                    name="personEdit"
                    label="Students name"
                    options={zaci}
                  />
                </Grid>
                <Grid item xs={12}>
                  <DateTimePicker name="startEdit"></DateTimePicker>
                </Grid>
                <Grid item xs={12}>
                  <Checkbox
                    name="oneTimeEdit"
                    legend="One time hour"
                    label="I want this hour to be one time"
                  />
                </Grid>
              </Grid>
              <DialogActions>
                <Grid item xs={6}>
                  <SubmitButton>Edit Changes</SubmitButton>
                </Grid>
                <Grid item xs={6}>
                  <Button
                    fullWidth
                    variant="contained"
                    color="secondary"
                    onClick={() => {
                      api.delete(`/Hour/${hour.id}`).then(() => {
                        <Alert severity="success">Hour Deleted</Alert>;
                      });
                      handleCloseDialogs();
                      setPersonId("");
                    }}
                  >
                    Delete
                  </Button>
                </Grid>
              </DialogActions>
            </Form>
          </Formik>
        </DialogContent>
      </Dialog>
    </>
  );
};
export default Cell;
