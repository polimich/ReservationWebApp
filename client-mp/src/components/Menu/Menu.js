import React, { useState } from "react";
import { Link } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from "reactstrap";
import {
  useAppContext,
  SET_ACCESS_TOKEN,
  SET_USER_ID,
  SET_ROLE,
  SET_NAME,
} from "../../providers/ApplicationProvider";

const Menu = () => {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);
  const [{ accessToken, name }, dispatch] = useAppContext();

  const onLogout = () => {
    toggle();
    dispatch({ type: SET_ACCESS_TOKEN, payload: null });
    dispatch({ type: SET_NAME, payload: null });
    dispatch({ type: SET_ROLE, payload: null });
    dispatch({ type: SET_USER_ID, payload: null });
  };
  return (
    <>
      <Navbar light expand="md">
        <NavbarBrand tag={Link} to="/home">
          Home
        </NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          {accessToken ? (
            <>
              <Nav className="mr-auto" navbar>
                <NavItem>
                  <NavLink tag={Link} to="/search" onClick={toggle}>
                    Search
                  </NavLink>
                </NavItem>
              </Nav>

              <Nav className="rightNav ml-auto" navbar>
                <UncontrolledDropdown nav inNavbar>
                  <DropdownToggle nav caret>
                    {name}
                  </DropdownToggle>
                  <DropdownMenu right>
                    <DropdownItem
                      tag={Link}
                      to="/usersettings"
                      onClick={toggle}
                    >
                      Settings
                    </DropdownItem>
                    <DropdownItem onClick={(e) => onLogout()}>
                      Logout
                    </DropdownItem>
                  </DropdownMenu>
                </UncontrolledDropdown>
              </Nav>
            </>
          ) : (
            <Nav className="rightNav ml-auto" navbar>
              <NavItem>
                <NavLink tag={Link} to="/login">
                  Login
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/register">
                  Register
                </NavLink>
              </NavItem>
            </Nav>
          )}
        </Collapse>
      </Navbar>
    </>
  );
};

export default Menu;
