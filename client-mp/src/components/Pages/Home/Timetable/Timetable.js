import React from "react";
import { Table } from "reactstrap";
import HeaderCell from "./HeaderCell";

const Timetable = () => {
  return (
    <>
      <Table responsive borderless size="sm">
        <thead>
          <tr>
            <HeaderCell title="Day/Time" />
            <HeaderCell title="8:00" />
            <HeaderCell title="9:00" />
            <HeaderCell title="10:00" />
            <HeaderCell title="11:00" />
            <HeaderCell title="12:00" />
            <HeaderCell title="13:00" />
            <HeaderCell title="14:00" />
            <HeaderCell title="15:00" />
            <HeaderCell title="16:00" />
            <HeaderCell title="17:00" />
            <HeaderCell title="18:00" />
            <HeaderCell title="19:00" />
          </tr>
        </thead>
        <tbody>
          <tr>
            <HeaderCell title="Monday" />
          </tr>
          <tr>
            <HeaderCell title="Tuesday" />
          </tr>
          <tr>
            <HeaderCell title="Wednesday" />
          </tr>
          <tr>
            <HeaderCell title="Thursday" />
          </tr>
          <tr>
            <HeaderCell title="Friday" />
          </tr>
        </tbody>
      </Table>
    </>
  );
};

export default Timetable;
