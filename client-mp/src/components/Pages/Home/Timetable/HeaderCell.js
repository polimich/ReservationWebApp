import { Card, CardContent, TableCell, Typography } from "@material-ui/core";
import React from "react";

const HeaderCell = ({ title }) => {
  console.log(title === "Monday");
  return (
    <TableCell
      variant={
        title === "Monday" ||
        title === "Tuesday" ||
        title === "Wednesday" ||
        title === "Thursday" ||
        title === "Friday" ||
        title === "Day/Time"
          ? "head"
          : "body"
      }
    >
      <Card>
        <CardContent>
          <Typography variant="h6">{title}</Typography>
        </CardContent>
      </Card>
    </TableCell>
  );
};

export default HeaderCell;
