import React from "react";
import { TextField, MenuItem } from "@material-ui/core";
import { useField, useFormikContext } from "formik";

const SelectWrapper = ({ name, options, ...otherProps }) => {
  const [field, meta] = useField(name);
  const { setFieldValue } = useFormikContext();
  const handleChange = (e) => {
    const { value } = e.target;
    setFieldValue(name, value);
  };
  const configSelect = {
    ...field,
    ...otherProps,
    select: true,
    variant: "outlined",
    fullWidth: true,
    onChange: handleChange,
  };
  if (meta && meta.touched && meta.error) {
    configSelect.error = true;
    configSelect.helperText = meta.error;
  }

  return (
    <TextField {...configSelect}>
      {options.map((option, index) => {
        return (
          <MenuItem key={index} value={option.id}>
            {option.name}
          </MenuItem>
        );
      })}
    </TextField>
  );
};

export default SelectWrapper;
