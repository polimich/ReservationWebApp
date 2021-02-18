import axios from "axios";
import React from "react";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom/cjs/react-router-dom.min";
import { ListGroup, ListGroupItem } from "reactstrap";
import API from "../../../api/api";

const ListSearchedUsers = ({ name }) => {
  const [users, setUsers] = useState([]);
  useEffect(() => {
    API.get("/Account").then((res) => {
      setUsers(res.data);
    });
  }, [name]);

  return (
    <>
      <ListGroup>
        {users.map(({ firstName, lastName, userName }) => {
          return firstName.toLowerCase().includes(name.toLowerCase()) ||
            lastName.toLowerCase().includes(name.toLowerCase()) ||
            userName.toLowerCase().includes(name.toLowerCase()) ? (
            <ListGroupItem tag={Link} to="/" key={userName}>
              {firstName + " " + lastName}
            </ListGroupItem>
          ) : (
            ""
          );
        })}
      </ListGroup>
    </>
  );
};

export default ListSearchedUsers;
