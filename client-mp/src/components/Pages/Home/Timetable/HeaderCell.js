import { Card, CardContent, TableCell, Typography } from "@material-ui/core";
import React from "react";

const HeaderCell = ({ title }) => {
  return (
    <TableCell>
      <Card>
        <CardContent>
          <Typography variant="h6">{title}</Typography>
        </CardContent>
      </Card>
    </TableCell>
  );
};

export default HeaderCell;
