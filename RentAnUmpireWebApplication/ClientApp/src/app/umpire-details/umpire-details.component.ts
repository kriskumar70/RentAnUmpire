import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'umpire-details',
    templateUrl: 'umpire-details.component.html'
})
export class UmpireDetailsComponent {
    public settings = {  
        columns: {  
          id: {  
            title: 'Id',  
            filter: true,  
          },  
          firstname: {  
            title: 'Firstname',  
            filter: true,  
          },  
          lastname: {  
            title: 'Lastname',  
            filter: true,  
          }  
        },  
        pager: {  
          display: true,  
          perPage: 10  
        },  
        actions: {  
          columnTitle: 'Action',  
          add: false,  
          edit: false,  
          delete: false,  
          position: 'left'  
        },  
        attr: {  
          class: 'table table-striped table-bordered table-hover'  
        },  
        defaultStyle: false  
      };  
      
      data = [  
        {  
          id: 1,  
          firstname: "Kaushik",  
          lastname: "dhameliya"  
        },  
        {  
          id: 2,  
          firstname: "Manish",  
          lastname: "Vadher"  
        },  
        {  
          id: 3,  
          firstname: "Sanket",  
          lastname: "Vagadiya"  
        },  
        {  
          id: 4,  
          firstname: "Vaibhav",  
          lastname: "Bavishi"  
        },  
        {  
          id: 5,  
          firstname: "Tushar",  
          lastname: "Kyada"  
        }];  
}
