import React from "react";
import { Card, CardBody, CardSubtitle, CardTitle } from "reactstrap";

const Cell = ({ title, body }) => {
  return (
    <td>
      <Card>
        <CardBody>
          <CardTitle>{title}</CardTitle>
          <CardSubtitle>{body}</CardSubtitle>
        </CardBody>
      </Card>
    </td>
  );
};

export default Cell;
