import React from "react";
import { Card, CardBody, CardSubtitle, CardTitle } from "reactstrap";

const HeaderCell = ({ title }) => {
  return (
    <th>
      <Card>
        <CardBody>
          <CardTitle>{title}</CardTitle>
        </CardBody>
      </Card>
    </th>
  );
};

export default HeaderCell;
