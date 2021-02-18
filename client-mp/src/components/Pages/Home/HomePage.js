import React from "react";
import { Col, Container, Row } from "reactstrap";
import Timetable from "./Timetable/Timetable";

const HomePage = () => {
  return (
    <Container fluid>
      <Row>
        <Col xs="8">
          <Timetable />
        </Col>
        <Col></Col>
      </Row>
    </Container>
  );
};

export default HomePage;
