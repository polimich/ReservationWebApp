import DateFnsUtils from "@date-io/date-fns";
import { Field, Form, Formik } from "formik";
import React from "react";
import * as Yup from "yup";
import {
  Box,
  FormControlLabel,
  Grid,
  makeStyles,
  MenuItem,
  Typography,
} from "@material-ui/core";
import { Switch } from "formik-material-ui";
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
import Textfield from "./FormUI/Textfield";
import Select from "./FormUI/Select";
import DateTimePicker from "./FormUI/DateTimePicker";
import Checkbox from "./FormUI/Checkbox";
import Button from "./FormUI/Button";
const useStyles = makeStyles((theme) => ({
  formWrapper: {
    marginTop: theme.spacing(5),
    marginBottom: theme.spacing(8),
  },
}));
const TestMaterialUIFormik = () => {
  const classes = useStyles();

  const predmety = { 1: "Tenis", 2: "Hrani her" };
  const zaci = {
    2: "Michael Polivka",
    3: "Karel Mavpici",
  };

  const treneri = { 1: "Pavel Markovic", 2: "Jura Jankovič" };

  const INITIAL_FORM_STATE = {
    email: "",
    name: "",
    person: "",
    start: new Date(),
    end: new Date(),
    oneTime: false,
    requester: "",
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
  return (
    <div className={classes.formWrapper}>
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
    </div>
  );
};

export default TestMaterialUIFormik;
