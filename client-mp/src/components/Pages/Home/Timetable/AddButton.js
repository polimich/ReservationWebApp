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
import React, { useEffect, useState } from "react";
import AddIcon from "@material-ui/icons/Add";
import Select from "../../../FormUI/Select";
import DateTimePicker from "../../../FormUI/DateTimePicker";
import Checkbox from "../../../FormUI/Checkbox";
import SubmitButton from "../../../FormUI/Button";
import { Form, Formik } from "formik";
import * as Yup from "yup";
import { useAppContext } from "../../../../providers/ApplicationProvider";
import { GetStudents } from "./Functions";
import api from "../../../../api/api";
require("datejs");

const AddButton = ({ userId }) => {
  const [{ accessToken, role, whatITeach }] = useAppContext();
  const [openDialog, setOpenDialog] = useState(false);
  const [zaci, setZaci] = useState();

  useEffect(() => {
    setZaci(GetStudents(userId));
    console.log(zaci);
  }, [userId]);

  const INITIAL_FORM_STATE = {
    name: whatITeach,
    person: "",
    start: Date.today().toISOString(),
    end: "",
    oneTime: false,
    requester: userId,
  };
  const FORM_VALIDATION = Yup.object().shape({
    person: Yup.string().required("Choose student"),
    oneTime: Yup.boolean(),
  });
  const handleOpen = () => {
    setOpenDialog(true);
  };
  const handleClose = () => {
    setOpenDialog(false);
  };

  return (
    <>
      <TableCell variant="head">
        <Button
          fullWidth
          variant="contained"
          color="primary"
          startIcon={<AddIcon />}
          onClick={() => {
            handleOpen();
          }}
        >
          Add Hour
        </Button>
      </TableCell>
      <Dialog open={openDialog} onClose={handleClose}>
        <DialogTitle>
          <Typography variant="h6">Add New Hour</Typography>
        </DialogTitle>
        <DialogContent>
          <Formik
            initialValues={{ ...INITIAL_FORM_STATE }}
            validationSchema={FORM_VALIDATION}
            onSubmit={async (values, { setSubmitting }) => {
              setSubmitting(true);
              api.post("/Hour", {
                name: values.name,
                person: values.person,
                start: Date.parse(values.start).addHours(1).toISOString(),
                end: Date.parse(values.start).addHours(2).toISOString(),
                requester: values.requester,
                isOneTime: values.isOneTime,
              });
              setSubmitting(false);
              handleClose();
              setSubmitting(true);
            }}
          >
            <Form>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <Select name="person" label="Students name" options={zaci} />
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
              </Grid>
              <DialogActions>
                <Grid item xs={12}>
                  <SubmitButton>Submit</SubmitButton>
                </Grid>
              </DialogActions>
            </Form>
          </Formik>
        </DialogContent>
      </Dialog>
    </>
  );
};

export default AddButton;
