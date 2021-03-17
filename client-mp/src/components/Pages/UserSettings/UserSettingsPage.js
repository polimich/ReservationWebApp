import { Grid, Typography } from "@material-ui/core";
import { Form, Formik } from "formik";
import React from "react";
import * as Yup from "yup";
import api from "../../../api/api";
import { useAppContext } from "../../../providers/ApplicationProvider";
import Textfield from "../../FormUI/Textfield";
import SubmitButton from "../../FormUI/Button";
import { Alert } from "@material-ui/lab";
const UserSettingsPage = () => {
  const [{ userId }] = useAppContext();
  return (
    <Formik
      initialValues={{
        oldPassword: "",
        newPassword: "",
        confirmNewPassword: "",
      }}
      validationSchema={Yup.object({
        oldPassword: Yup.string().required(
          "You must enter old poassword in order to change password"
        ),
        newPassword: Yup.string()
          .min(8, "Password is too short")
          .required("Enter new password"),
        confirmNewPassword: Yup.string().oneOf(
          [Yup.ref("password"), null],
          "Passwords must match"
        ),
      })}
      onSubmit={async (values, { setSubmitting }) => {
        setSubmitting(true);
        api
          .put(`Account/${userId}`, {
            oldPassword: values.oldPassword,
            newPassword: values.newPassword,
            confirmNewPassword: values.confirmNewPassword,
          })
          .then((res) => {
            <Alert severity="success">Password changed successfully</Alert>;
          });
      }}
    >
      <Form>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <Typography variant="h6">Change your password:</Typography>
          </Grid>
          <Grid item xs={12}>
            <Textfield name="oldPassword" label="Enter Old Password" />
          </Grid>
          <Grid item xs={12}>
            <Textfield name="newPassword" label="Enter New Password" />
          </Grid>
          <Grid item xs={12}>
            <Textfield name="confirmNewPassword" label="Confirm New Password" />
          </Grid>
          <Grid item xs={12}>
            <SubmitButton>Change password</SubmitButton>
          </Grid>
        </Grid>
      </Form>
    </Formik>
  );
};

export default UserSettingsPage;
