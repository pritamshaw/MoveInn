function User(data)
{
    if (data == null) {
        data = {};
        data.RowID = 0;
        data.ID = null;
        data.FirstName = '';
        data.LastName = '';
        data.Email = '';
        data.EmailVerified = false;
        data.Zip = '0';
        data.BirthDate = new moment().format('MM-DD-YYYY');
        data.UserName = '';
        data.Password = '';
        data.AgreedToTermsDate = new moment().format('MM-DD-YYYY');
        data.LastLogonTime = '';
        data.CreatedOn = new moment().format('MM-DD-YYYY');
        data.CreatedBy = 1;//currentUser.ID;
        data.ModifiedOn = new moment().format('MM-DD-YYYY');
        data.ModifiedBy = 1;//currentUser.ID;
        data.IsActive = true;
    }

    var self = this;
    self.RowID = data.RowID;
    self.ID = data.ID;
    self.FirstName = ko.observable(data.FirstName);
    self.LastName = ko.observable(data.LastName);
    self.EmailVerified = ko.observable(data.EmailVerified);
    self.Email = ko.observable(data.Email);
    self.Zip = ko.observable(data.Zip);
    self.BirthDate = ko.observable(new moment(data.BirthDate).format('MM-DD-YYYY'));
    self.UserName = ko.observable(data.UserName);
    self.Password = ko.observable(data.Password);
    self.AgreedToTermsDate = ko.observable(new moment(data.AgreedToTermsDate).format('MM-DD-YYYY'));
    self.LastLogonTime = ko.observable(new moment(data.LastLogonTime).format('MM-DD-YYYY'));
    self.CreatedOn = ko.observable(data.CreatedOn);
    self.CreatedBy = ko.observable(data.CreatedBy);
    self.ModifiedOn = ko.observable(data.ModifiedOn);
    self.ModifiedBy = ko.observable(data.ModifiedBy);
    self.IsActive = ko.observable(data.IsActive);

}

function UserView() {
    var self = this;
    self.grid;
    self.Users = ko.observableArray([]);
    self.selectedUser = ko.observable(null);
    self.newUser = ko.observable(new User(null));

    self.popupAddMode = ko.observable(false);
    self.change_popupAddMode = function change_popupAddMode(mode) {
        self.popupAddMode(mode);
        if (mode == true) {
            self.selectedUser(new User(null));
            if (self.grid)
                self.grid.bootgrid("deselect");
        }
    }

    self.loadUsers = function GetAllEmployees() {
        jQuery.support.cors = true;
        $.ajax({
            url: 'http://localhost:4026/api/user',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                var mappedUsers = $.map(data, function (item) { return new User(item); });
                self.Users(mappedUsers);
                self.grid = $("#grid-basic").bootgrid({
                    selection: true,
                    rowSelect: true,
                    keepSelection: true,
                    formatters: {
                        "chkVerified": function (column, row) {
                            if (row.EmailVerified == "true")
                                return '<i class="fa fa-check"></i>';
                            else
                                return '<i class="fa fa-times"></i>';
                        },
                        "chkActive": function (column, row) {
                            if (row.IsActive == "true")
                                return '<i class="fa fa-check"></i>';
                            else
                                return '<i class="fa fa-times"></i>';
                        }
                    }
                }).on("selected.rs.jquery.bootgrid", function (e, rows) {
                    var match = ko.utils.arrayFirst(self.Users(), function (item) {
                        return rows[0].ID === item.ID;
                    });
                    if (match) {
                        self.selectedUser(match);
                    }
                }).on("deselected.rs.jquery.bootgrid", function (e, rows) {
                    self.selectedUser(new User(null));
                });
                toastr.info('Users Loaded Successfully');
            },
            error: function (data) {
                alert(data);
            }
        });
    };

    self.addUser = function addUser() {

        if (self.newUser()) {
            var Item = {};
            Item.RowID = 0;
            Item.ID = null;
            Item.FirstName = self.newUser().FirstName();
            Item.LastName = self.newUser().LastName();
            Item.Email = self.newUser().Email();
            Item.EmailVerified = self.newUser().EmailVerified();
            Item.Zip = self.newUser().Zip();
            Item.BirthDate = new moment(self.newUser().BirthDate()).format('MM-DD-YYYY');
            Item.UserName = self.newUser().UserName();
            Item.Password = self.newUser().Password();
            Item.AgreedToTermsDate = new moment().format('MM-DD-YYYY');
            Item.LastLogonTime = null;
            Item.CreatedOn = new moment().format('MM-DD-YYYY');
            Item.CreatedBy = 1;//currentUser.ID;
            Item.ModifiedOn = new moment().format('MM-DD-YYYY');
            Item.ModifiedBy = 1;//currentUser.ID;
            Item.IsActive = self.newUser().IsActive();;

            $.ajax({
                url: core.URL + '/api/user/add',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json',
                data: JSON.stringify(Item),
                processData: false,
                success: function (data) {
                    if (self.grid) {
                        self.grid.bootgrid("append", new User(data));
                    }
                    toastr.success("User created successfully!")
                },
                error: function (data) {
                    toastr.warning("User creation failed!")
                }
            });
        }

    }

    self.updateUser = function updateUser() {

        if (self.selectedUser()) {

            $.getJSON(core.URL + '/api/user/' + self.selectedUser().RowID, function (data) {
                console.log("success retrieving record");
            })
                  .done(function (data) {
                      if (data) {
                          var Item = data;
                          Item.FirstName = self.selectedUser().FirstName();
                          Item.LastName = self.selectedUser().LastName();
                          Item.Email = self.selectedUser().Email();
                          Item.EmailVerified = self.selectedUser().EmailVerified();
                          Item.Zip = self.selectedUser().Zip();
                          Item.BirthDate = self.selectedUser().BirthDate() == null ? null : new moment(self.selectedUser().BirthDate()).format('MM-DD-YYYY');
                          Item.UserName = self.selectedUser().UserName();
                          Item.Password = self.selectedUser().Password();
                          Item.AgreedToTermsDate = new moment(self.selectedUser().AgreedToTermsDate()).format('MM-DD-YYYY');
                          Item.LastLogonTime = self.selectedUser().LastLogonTime() == null ? null : new moment(self.selectedUser().LastLogonTime()).format('MM-DD-YYYY');;
                          Item.CreatedOn = new moment(data.CreatedOn).format('MM-DD-YYYY');
                          Item.CreatedBy = data.CreatedBy;
                          Item.ModifiedOn = new moment().format('MM-DD-YYYY');
                          Item.ModifiedBy = 1;//currentUser.ID;
                          Item.IsActive = self.selectedUser().IsActive();;

                          $.ajax({
                              url: core.URL + '/api/user/update',
                              dataType: 'json',
                              type: 'post',
                              contentType: 'application/json',
                              data: JSON.stringify(Item),
                              processData: false,
                              success: function (data) {
                                  if (self.grid) {
                                      self.grid.bootgrid("append", new User(data));
                                  }
                                  toastr.success("User updated successfully!")
                              },
                              error: function (data) {
                                  toastr.warning("User updation failed!")
                              }
                          });
                      }
                      else {
                          console.log("error");
                          return null;
                      }
                  })
                  .fail(function (data) {
                      console.log("error");
                      return null;
                  });

            
        }

    }

    self.deleteUser = function deleteUser() {
        
        if (self.selectedUser()) {
            self.selectedUser(self.getUser(self.selectedUser().RowID));
            
        }

    }

    self.loadUsers();

}


$(document).ready(function () {

    ko.applyBindings(new UserView());

    
    
});