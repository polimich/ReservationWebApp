import { Form, Formik } from "formik";
import React from "react";
import * as Yup from "yup";
import api from "../../../api/api";
import { useAppContext } from "../../../providers/ApplicationProvider";

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
          .put(
            `Account/${userId}`,
            {
              oldPassword: values.oldPassword,
              newPassword: values.newPassword,
              confirmNewPassword: values.confirmNewPassword,
            },
            { headers: { "Content-type": "application/json" } }
          )
          .then((res) => {});
      }}
    >
      <Form></Form>
    </Formik>
  );
};

export default UserSettingsPage;
