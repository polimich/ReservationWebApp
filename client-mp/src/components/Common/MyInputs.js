import { useField } from "formik";
import React from "react";
import { Alert, FormGroup, Input, Label } from "reactstrap";
import DateView from "react-datepicker";
export const MyTextInput = ({ label, ...props }) => {
  const [field, meta] = useField(props);
  return (
    <FormGroup>
      <Label className="bold" for={props.id || props.name}>
        {label}
      </Label>
      <Input type="text" {...field} {...props} />
      {meta.touched && meta.error ? (
        <Alert color="danger">{meta.error}</Alert>
      ) : null}
    </FormGroup>
  );
};
export const MySelect = ({ label, ...props }) => {
  const [field, meta] = useField(props);
  return (
    <FormGroup>
      <Label className="label" htmlFor={props.id || props.name}>
        {label}
      </Label>
      <Input type="select" {...field} {...props} />
      {meta.touched && meta.error ? (
        <Alert className="error" color="danger">
          {meta.error}
        </Alert>
      ) : null}
    </FormGroup>
  );
};
export const MyCheckbox = ({ children, ...props }) => {
  const [field, meta] = useField({ ...props, type: "checkbox" });
  return (
    <>
      <Label className="checkbox-input">
        <Input addon type="checkbox" {...field} {...props} />
        {children}
      </Label>
      {meta.touched && meta.error ? (
        <Alert color="danger">{meta.error}</Alert>
      ) : null}
    </>
  );
};
export const MyDatePicker = (label, ...props) => {
  const [field, meta] = useField;
  return <></>;
};
