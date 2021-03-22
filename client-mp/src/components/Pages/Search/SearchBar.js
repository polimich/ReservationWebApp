import { Grid, TextField, Typography } from "@material-ui/core";
import React from "react";

//* Komponenta sloužící k zadání výrazu, kterým se má filtrovat seznam uživatelů
const SearchBar = ({ label, term, setTerm }) => {
  return (
    <Grid container spacing={2}>
      <Grid item xs={12}>
        <Typography variant="h6">{label}</Typography>
      </Grid>
      <Grid item xs={12}>
        <TextField
          type="text"
          value={term}
          onChange={(e) => setTerm(e.target.value)}
          fullWidth
          label="Look up user:"
        />
      </Grid>
    </Grid>
  );
};

export default SearchBar;
