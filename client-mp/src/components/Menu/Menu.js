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

const Menu = () => {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);
  return (
    <div>
      <Navbar light expand="md">
        <NavbarBrand tag={Link} to="/home">
          Home
        </NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
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
                AccountName
              </DropdownToggle>
              <DropdownMenu right>
                <DropdownItem tag={Link} to="/usersettings" onClick={toggle}>
                  Settings
                </DropdownItem>
                <DropdownItem tag={Link} to="/logout" onClick={toggle}>
                  Logout
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  );
};

export default Menu;
