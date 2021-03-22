import { Grid } from "@material-ui/core";
import React from "react";
import { useState } from "react/cjs/react.development";
import { Container } from "reactstrap";
import ListSearchedUsers from "./ListSearchedUsers";
import SearchBar from "./SearchBar";

//* Komponenta složící pro získání, zobrazování a filtrování seznamu uživatelů
const SearchPage = () => {
  const [term, setTerm] = useState("");
  return (
    <Container>
      <SearchBar label="Lookup user" term={term} setTerm={setTerm} />
      <Grid item xs={12} />
      <ListSearchedUsers term={term} />
    </Container>
  );
};

export default SearchPage;
