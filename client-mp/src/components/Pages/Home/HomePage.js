import React from "react";
import { Col, Container, Row } from "reactstrap";
import ListUsers from "./ListUsers";
import Timetable from "./Timetable/Timetable";

const HomePage = () => {
  return (
    <Container fluid>
      <Row>
        <Col xs="8">
          <Timetable />
        </Col>
        <Col>
          <ListUsers />
        </Col>
      </Row>
    </Container>
  );
};

export default HomePage;
