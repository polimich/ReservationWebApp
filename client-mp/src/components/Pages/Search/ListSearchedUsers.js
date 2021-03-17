import { List, ListItem, ListItemIcon, ListItemText } from "@material-ui/core";
import axios from "axios";
import React from "react";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom/cjs/react-router-dom.min";
import { ListGroup, ListGroupItem } from "reactstrap";
import API from "../../../api/api";
import PersonIcon from "@material-ui/icons/Person";

const ListSearchedUsers = ({ name }) => {
  const [users, setUsers] = useState([]);
  useEffect(() => {
    API.get("/Account").then((res) => {
      setUsers(res.data);
    });
  }, [name]);

  return (
    <>
      <List component="nav">
        {users.map(({ firstName, lastName, userName, id }) => {
          return firstName.toLowerCase().includes(name.toLowerCase()) ||
            lastName.toLowerCase().includes(name.toLowerCase()) ||
            userName.toLowerCase().includes(name.toLowerCase()) ? (
            <ListItem
              button
              component={Link}
              to={`/userInfo/${id}`}
              key={userName}
            >
              <ListItemIcon>
                <PersonIcon />
              </ListItemIcon>
              <ListItemText primary={firstName + " " + lastName} />
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
