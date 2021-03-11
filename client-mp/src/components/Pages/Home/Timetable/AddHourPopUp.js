import {
  Dialog,
  DialogContent,
  DialogTitle,
  Grid,
  Typography,
} from "@material-ui/core";
import { Form, Formik } from "formik";
import Textfield from "../../../FormUI/Textfield";
import Select from "../../../FormUI/Select";
import DateTimePicker from "../../../FormUI/DateTimePicker";
import Checkbox from "../../../FormUI/Checkbox";

import React from "react";

const AddHourPopUp = ({}) => {
  return (
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
              <Grid item xs={6}>
                <Select
                  name="requester"
                  label="Trainers name"
                  options={treneri}
                />
              </Grid>
              <Grid item xs={6}>
                <Select name="person" label="Students name" options={zaci} />
              </Grid>
              <Grid item xs={12}>
                <Select name="name" label="Hour type" options={predmety} />
              </Grid>
              <Grid item xs={12}>
                <Textfield name="email" label="Email" />
              </Grid>
              <Grid item xs={6}>
                <DateTimePicker name="start" label="Hour start" />
              </Grid>
              <Grid item xs={6}>
                <DateTimePicker name="end" label="Hour end" />
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
  );
};

export default AddHourPopUp;
