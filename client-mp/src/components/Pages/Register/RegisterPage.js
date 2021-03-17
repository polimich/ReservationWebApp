import React, { useEffect, useState } from "react";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import {
  useAppContext,
  SET_ACCESS_TOKEN,
  SET_NAME,
  SET_ROLE,
  SET_USER_ID,
  SET_WHAT_I_TEACH,
} from "../../../providers/ApplicationProvider";
import api from "../../../api/api";
import { Container, Grid, Typography } from "@material-ui/core";
import Textfield from "../../FormUI/Textfield";
import Select from "../../FormUI/Select";
import Button from "../../FormUI/Button";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";

const RegisterPage = () => {
  const [
    { accessToken, name, role, userId, whatITeach },
    dispatch,
  ] = useAppContext();
  const [isRole, setRole] = useState(true);
  const history = useHistory();
  return (
    <Container maxWidth="md">
      <Formik
        initialValues={{
          email: "",
          firstname: "",
          lastname: "",
          password: "",
          confirmPassword: "",
          role: "",
          whatITeach: "",
        }}
        validationSchema={Yup.object({
          password: Yup.string()
            .min(8, "Password is too short")
            .required("No password provided"),
          confirmPassword: Yup.string().oneOf(
            [Yup.ref("password"), null],
            "Passwords must match"
          ),

          email: Yup.string()
            .email("Invalid email address")
            .required("Email required"),
          firstname: Yup.string().required("Enter your firstName"),
          lastname: Yup.string().required("Enter your lastname"),
          role: Yup.string().oneOf(["Student", "Trener"]).required("Required"),
          whatITeach: Yup.string().when("role", {
            is: "Trener",
            then: Yup.string().required("Must enter what you teach"),
          }),
        })}
        onSubmit={async (values, { setSubmitting }) => {
          setSubmitting(true);
          api
            .post(
              "/Account/register",
              {
                email: values.email,
                password: values.password,
                confirmPassword: values.confirmPassword,
                firstname: values.firstname,
                lastName: values.lastname,
                role: values.role,
                whatITeach: values.whatITeach,
              },
              {
                headers: {
                  "Content-Type": "application/json",
                },
              }
            )
            .then((response) => {
              dispatch({
                type: SET_ACCESS_TOKEN,
                payload: response.data.token.accessToken,
              });
              dispatch({
                type: SET_NAME,
                payload: response.data.name,
              });
              dispatch({ type: SET_ROLE, payload: response.data.role });
              dispatch({ type: SET_USER_ID, payload: response.data.userId });
              dispatch({
                type: SET_WHAT_I_TEACH,
                payload: response.data.whatITeach,
              });
              console.log(response.data);
              setSubmitting(false);
              history.push("/home");
            })
            .catch((err) => {
              alert("Chybicka");
            })
            .then(() => {
              setSubmitting(false);
            });
        }}
      >
        <Form>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <Typography variant="h3">Register</Typography>
            </Grid>
            <Grid item xs={12}>
              <Textfield name="email" label="Enter Email:" />
            </Grid>
            <Grid item xs={6}>
              <Textfield name="firstname" label="First Name:" />
            </Grid>
            <Grid item xs={6}>
              <Textfield name="lastname" label="Lastname:" />
            </Grid>
            <Grid item xs={6}>
              <Textfield name="password" type="password" label="Password:" />
            </Grid>
            <Grid item xs={6}>
              <Textfield
                name="confirmPassword"
                type="password"
                label="Confirm password:"
              />
            </Grid>
            <Grid item xs={6}>
              <Select
                name="role"
                options={[
                  { id: "Student", name: "Student" },
                  { id: "Trener", name: "Trainer" },
                ]}
                label="Choose role"
                onClick={(e) =>
                  setRole(e.target.value === "Trener" ? false : true)
                }
              />
            </Grid>
            <Grid item xs={6}>
              <Textfield
                name="whatITeach"
                label={isRole ? "Only for Trainers :)" : "What I teach"}
                disabled={isRole}
              />
            </Grid>
            <Grid item xs={12}>
              <Button>Register</Button>
            </Grid>
          </Grid>
        </Form>
      </Formik>
    </Container>
  );
};
export default RegisterPage;
