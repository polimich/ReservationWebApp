import React from "react";
import { Input, Label } from "reactstrap";
const SearchBar = ({ label, term, setTerm }) => {
  return (
    <>
      <Label>{label}</Label>
      <Input
        type="text"
        value={term}
        onChange={(e) => setTerm(e.target.value)}
      />
    </>
  );
};

export default SearchBar;
