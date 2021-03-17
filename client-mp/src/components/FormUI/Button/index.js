import React from "react";
import { Button } from "@material-ui/core";
import { useFormikContext } from "formik";

const ButtonWrapper = ({ children, ...otherProps }) => {
  const { submitForm } = useFormikContext();
  const handleSubmit = () => {
    console.log("ahoj");
    submitForm();
  };
  const configButton = {
    variant: "contained",
    color: "primary",
    fullWidth: true,
    onClick: handleSubmit,
    ...otherProps,
  };
  return <Button {...configButton}>{children}</Button>;
};

export default ButtonWrapper;
