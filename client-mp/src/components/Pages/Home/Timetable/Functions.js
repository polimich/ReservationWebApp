import api from "../../../../api/api";

export const GetStudents = (userId) => {
  var currentPerson = "";
  var zaci = [];
  api.get(`/Hour/GetAllUsersHours/${userId}`).then((response) => {
    response.data.map(({ person }) => {
      //Vytvori seznam zaku, ktere trener uci
      if (currentPerson !== person) {
        currentPerson = person;
        api.get(`/Account/${person}`).then((response) => {
          zaci.push({
            id: person,
            name: response.data.firstName + " " + response.data.lastName,
          });
        });
      }
    });
  });
  return zaci;
};
