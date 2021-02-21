import React from "react";
import { Link } from "react-router-dom";
import { useEffect, useState } from "react/cjs/react.development";
import { ListGroup, ListGroupItem } from "reactstrap";
import api from "../../../api/api";

const ListUsers = () => {
  const [hours, setHours] = useState([]);
  useEffect(() => {
    api
      .get("/Hour/GetUsersWeek/", {
        params: {
          userid: 2,
          startdate: "2021-02-10T08-00-00",
        },
      })
      .then((res) => {
        setHours(res.data);
      });
  }, []);
  const role = "Trener";

  if (role === "Trener") {
    return (
      <ListGroup>
        {hours.map(({ person }) => {
          return (
            <ListGroupItem tag={Link} to="/" key={person}>
              {person}
            </ListGroupItem>
          );
        })}
      </ListGroup>
    );
  } else {
    return (
      <ListGroup>
        {hours.map(({ requester }) => {
          return (
            <ListGroupItem tag={Link} to="/" key={requester}>
              {requester}
            </ListGroupItem>
          );
        })}
      </ListGroup>
    );
  }
};

export default ListUsers;
