import React from "react";
import { Formik, Form } from "formik";
import * as Yup from "yup";
//import { Input, Form } from "react-formik-ui";
import {
  useAppContext,
  SET_ACCESS_TOKEN,
  SET_NAME,
  SET_ROLE,
  SET_USER_ID,
  SET_WHAT_I_TEACH,
} from "../../../providers/ApplicationProvider";
import api from "../../../api/api";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { Container, Grid } from "@material-ui/core";
import Textfield from "../../FormUI/Textfield";
import Button from "../../FormUI/Button";
// And now we can use these
const LoginPage = () => {
  const [
    { accessToken, name, role, userId, whatITeach },
    dispatch,
  ] = useAppContext();
  const history = useHistory();
  return (
    <Container maxWidth="md">
      <h1>Log in to use the application</h1>
      <Formik
        initialValues={{
          email: "",
          password: "",
        }}
        validationSchema={Yup.object({
          password: Yup.string()
            .min(8, "Password is too short")
            .required("No password provided"),
          email: Yup.string()
            .email("Invalid email address")
            .required("Required"),
        })}
        onSubmit={async (values, { setSubmitting }) => {
          setSubmitting(true);
          api
            .post(
              "/Account/login",
              {
                email: values.email,
                password: values.password,
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

              console.log(userId);
            })
            .catch((err) => {
              alert("Chybicka");
            })
            .then(() => {
              setSubmitting(false);
            });

          setSubmitting(false);
          history.push("/home");
        }}
      >
        <Form>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <Textfield name="email" label="Enter Email:" />
            </Grid>
            <Grid item xs={12}>
              <Textfield name="password" type="password" label="Password:" />
            </Grid>
            <Grid item xs={12}>
              <Button>Log in</Button>
            </Grid>
          </Grid>
        </Form>
      </Formik>
    </Container>
  );
};
export default LoginPage;
