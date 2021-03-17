import {
  makeStyles,
  Paper,
  Table,
  TableBody,
  TableContainer,
  TableHead,
  TableRow,
} from "@material-ui/core";
import React, { useRef } from "react";
import { useParams } from "react-router-dom/cjs/react-router-dom.min";
import { useAppContext } from "../../../../providers/ApplicationProvider";
import Cell from "./Cell";
import HeaderCell from "../../Home/Timetable/HeaderCell";
const useStyles = makeStyles({
  table: {
    minWidth: 650,
  },
});

const UserTimetable = () => {
  var { userID } = useParams();
  const monday = getDates(0);
  const tuesday = getDates(1);
  const wednesday = getDates(2);
  const thursday = getDates(3);
  const friday = getDates(4);
  const [{ accessToken, userId, role }] = useAppContext();
  var user = userID === undefined ? userId : userID;

  const scrollRef = useRef(null);
  const onWheel = (e) => {
    const table = scrollRef.current;
    const tableScrollPos = scrollRef.current.scrollLeft;

    table.scrollTo({
      top: 0,
      left: tableScrollPos + e.deltaY,
      behaviour: "smooth",
    });
  };
  const classes = useStyles();
  return (
    <>
      <Paper elevation={2}>
        <TableContainer ref={scrollRef}>
          <Table
            stickyHeader
            size="small"
            className={classes.table}
            onWheel={onWheel}
          >
            <TableHead>
              <TableRow>
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
              </TableRow>
            </TableHead>
            <TableBody>
              <TableRow>
                <HeaderCell title="Monday" />
                <Cell date={monday[0]} userId={user} />
                <Cell date={monday[1]} userId={user} />
                <Cell date={monday[2]} userId={user} />
                <Cell date={monday[3]} userId={user} />
                <Cell date={monday[4]} userId={user} />
                <Cell date={monday[5]} userId={user} />
                <Cell date={monday[6]} userId={user} />
                <Cell date={monday[7]} userId={user} />
                <Cell date={monday[8]} userId={user} />
                <Cell date={monday[9]} userId={user} />
                <Cell date={monday[10]} userId={user} />
                <Cell date={monday[11]} userId={user} />
              </TableRow>
              <TableRow>
                <HeaderCell title="Tuesday" />
                <Cell date={tuesday[0]} userId={user} />
                <Cell date={tuesday[1]} userId={user} />
                <Cell date={tuesday[2]} userId={user} />
                <Cell date={tuesday[3]} userId={user} />
                <Cell date={tuesday[4]} userId={user} />
                <Cell date={tuesday[5]} userId={user} />
                <Cell date={tuesday[6]} userId={user} />
                <Cell date={tuesday[7]} userId={user} />
                <Cell date={tuesday[8]} userId={user} />
                <Cell date={tuesday[9]} userId={user} />
                <Cell date={tuesday[10]} userId={user} />
                <Cell date={tuesday[11]} userId={user} />
              </TableRow>
              <TableRow>
                <HeaderCell title="Wednesday" />
                <Cell date={wednesday[0]} userId={user} />
                <Cell date={wednesday[1]} userId={user} />
                <Cell date={wednesday[2]} userId={user} />
                <Cell date={wednesday[3]} userId={user} />
                <Cell date={wednesday[4]} userId={user} />
                <Cell date={wednesday[5]} userId={user} />
                <Cell date={wednesday[6]} userId={user} />
                <Cell date={wednesday[7]} userId={user} />
                <Cell date={wednesday[8]} userId={user} />
                <Cell date={wednesday[9]} userId={user} />
                <Cell date={wednesday[10]} userId={user} />
                <Cell date={wednesday[11]} userId={user} />
              </TableRow>
              <TableRow>
                <HeaderCell title="Thursday" />
                <Cell date={thursday[0]} userId={user} />
                <Cell date={thursday[1]} userId={user} />
                <Cell date={thursday[2]} userId={user} />
                <Cell date={thursday[3]} userId={user} />
                <Cell date={thursday[4]} userId={user} />
                <Cell date={thursday[5]} userId={user} />
                <Cell date={thursday[6]} userId={user} />
                <Cell date={thursday[7]} userId={user} />
                <Cell date={thursday[8]} userId={user} />
                <Cell date={thursday[9]} userId={user} />
                <Cell date={thursday[10]} userId={user} />
                <Cell date={thursday[11]} userId={user} />
              </TableRow>
              <TableRow>
                <HeaderCell title="Friday" />
                <Cell date={friday[0]} userId={user} />
                <Cell date={friday[1]} userId={user} />
                <Cell date={friday[2]} userId={user} />
                <Cell date={friday[3]} userId={user} />
                <Cell date={friday[4]} userId={user} />
                <Cell date={friday[5]} userId={user} />
                <Cell date={friday[6]} userId={user} />
                <Cell date={friday[7]} userId={user} />
                <Cell date={friday[8]} userId={user} />
                <Cell date={friday[9]} userId={user} />
                <Cell date={friday[10]} userId={user} />
                <Cell date={friday[11]} userId={user} />
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
    </>
  );
};
const getDates = (i, separator = "-") => {
  let today = new Date();
  let dates = [];
  var monday = setToMonday(today);

  let time = 8;
  var date = new Date(monday);
  date.setDate(monday.getDate() + i);
  let day = date.getDate();
  let month = date.getMonth() + 1;
  let year = date.getFullYear();
  while (time < 20) {
    dates.push(
      `${year}${separator}${month < 10 ? `0${month}` : `${month}`}${separator}${
        day < 10 ? `0${day}` : `${day}`
      }T${time < 10 ? `0${time}` : `${time}`}:00:00`
    );
    time = time + 1;
  }

  return dates;
};
const setToMonday = (date) => {
  var day = date.getDay() || 7;
  if (day !== 1) date.setHours(-24 * (day - 1));
  return date;
};

export default UserTimetable;
