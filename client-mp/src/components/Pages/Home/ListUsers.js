import {
  CircularProgress,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@material-ui/core";
import React from "react";
import { Link } from "react-router-dom";
import { useEffect, useState } from "react/cjs/react.development";
import api from "../../../api/api";
import { useAppContext } from "../../../providers/ApplicationProvider";
require("datejs");

//* Komponenta zobrazující list uživatelů(Trenérů/studentu) podle role prihlaseneho uzivatele (Studenta/Trenera)
const ListUsers = () => {
  //const start = Date.today().toString("yyyy-MM-ddTHH:mm:ss");
  const [{ role, userId }] = useAppContext();
  const [personArr, setPersonArr] = useState();
  const [loading, setLoading] = useState(false);
  //* Dotaz na api pro ziskani dat
  useEffect(() => {
    setLoading(true);
    api
      .get(`/Account/GetUsersStudents/${userId}`)
      .then((response) => {
        const users = response.data;
        // pomoci funkce map se projde odpoved a vytvori seznam uzivatelu
        const renderedUsers = users.map(({ id, name }) => {
          return (
            <TableRow key={id}>
              <TableCell component={Link} to={`/userInfo/${id}`}>
                {name}
              </TableCell>
            </TableRow>
          );
        });
        setPersonArr(renderedUsers);
      })
      .finally(() => {
        setLoading(false);
      });
  }, [userId]);

  return (
    <Paper elevation={2}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>
              {role === "Trener" ? "Students:" : "Teacher:"}
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {/* Dokud se nenactou data z API zobrazuje se Spinner */}
          {loading ? (
            <TableCell>
              <CircularProgress />
            </TableCell>
          ) : (
            personArr
          )}
        </TableBody>
      </Table>
    </Paper>
  );
};
export default ListUsers;
