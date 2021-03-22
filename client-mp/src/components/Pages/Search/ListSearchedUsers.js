import { List, ListItem, ListItemIcon, ListItemText } from "@material-ui/core";
import React from "react";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom/cjs/react-router-dom.min";
import API from "../../../api/api";
import PersonIcon from "@material-ui/icons/Person";

//* Komponenta složící pro získání, zobrazování a filtrování seznamu uživatelů
const ListSearchedUsers = ({ term }) => {
  const [users, setUsers] = useState([]);
  useEffect(() => {
    API.get("/Account").then((res) => {
      setUsers(res.data);
    });
  }, [term]);

  return (
    <>
      <List component="nav">
        {users.map(({ name, id }) => {
          return name.toLowerCase().includes(term.toLowerCase()) ? (
            <ListItem button component={Link} to={`/userInfo/${id}`} key={id}>
              <ListItemIcon>
                <PersonIcon />
              </ListItemIcon>
              <ListItemText primary={name} />
            </ListItem>
          ) : (
            ""
          );
        })}
      </List>
    </>
  );
};

export default ListSearchedUsers;
