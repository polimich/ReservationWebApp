import React from "react";
import { useState } from "react/cjs/react.development";
import { Container } from "reactstrap";
import ListSearchedUsers from "./ListSearchedUsers";
import SearchBar from "./SearchBar";

const SearchPage = () => {
  const [term, setTerm] = useState("");
  return (
    <Container>
      <SearchBar label="Lookup user" term={term} setTerm={setTerm} />
      {console.log({ term })}
      <br />
      <ListSearchedUsers name={term} />
    </Container>
  );
};

export default SearchPage;
