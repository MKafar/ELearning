import React, { Component } from 'react';
import { Button, Header, Modal, Dropdown } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddSection.scss';

const sectionptions = [
    { key: 1, value: 1, text: '1' },
    { key: 2, value: 2, text: '2' },
    { key: 3, value: 3, text: '3' },
    { key: 4, value: 4, text: '4' },
    { key: 5, value: 5, text: '5' },
    { key: 6, value: 6, text: '6' },
    { key: 7, value: 7, text: '7' },
    { key: 8, value: 8, text: '8' },
    { key: 9, value: 9, text: '9' },
    { key: 10, value: 10, text: '10' },    
    { key: 11, value: 11, text: '11' },
    { key: 12, value: 12, text: '12' },
    { key: 13, value: 13, text: '13' },
    { key: 14, value: 14, text: '14' },
    { key: 15, value: 15, text: '15' },
    { key: 16, value: 16, text: '16' },
    { key: 17, value: 17, text: '17' },
    { key: 18, value: 18, text: '18' },
    { key: 19, value: 19, text: '19' },
    { key: 20, value: 20, text: '20' },
    { key: 21, value: 21, text: '21' },
    { key: 22, value: 22, text: '22' },
    { key: 23, value: 23, text: '23' },
    { key: 24, value: 24, text: '24' },
    { key: 25, value: 25, text: '25' },
    { key: 26, value: 26, text: '26' },
    { key: 27, value: 27, text: '27' },
    { key: 28, value: 28, text: '28' },
    { key: 29, value: 29, text: '29' },
    { key: 30, value: 30, text: '30' },
    
];

class ModalAddSection extends Component {

    state = {
        number: null,
        studentOptions: [],
        user: null
    }

    handleChange = (e, { value }) => {
        this.setState({ number: value });
    }
    handleChangeStudents = (e, { value }) => {
        this.setState({ user: value });   
    }
    componentDidMount = () => {
        axios.get('/api/Users/GetAll')
            .then(response => {
                console.log(response.data.users);
                const us = response.data.users;
                let i;

                for (i = 0; i < us.length; i++) {
                    us[i].text = us[i]['name'];
                    us[i].key = us[i]['id'];
                    us[i].value = us[i]['id'];
                    
                }
                this.setState({ studentOptions: response.data.users })
            }).catch(error => {
                console.log(error.response);
            })
    }

    addHandle = () => {
        const inputSectionNumber = this.state.number;
        const selectedGroup = this.props.selectedGroupID;
        const selectedUser = this.state.user;
        axios.post('/api/Sections/Create', {
            number: inputSectionNumber,
            groupid: selectedGroup,
           userid: selectedUser
        })
            .then(response => {
                console.log(response.data);
                this.props.updateData();
            })
            .catch(error => {
                console.log(error.response);
                alert("Nie można dodać sekcji!")
            })
    }
    render() {



        return (
            <Modal closeIcon trigger={<Button primary className='modalbutton'>Dodaj sekcję</Button>} centered={false}>
                <Modal.Header>Dodaj sekcję</Modal.Header>
                <Modal.Content >
                    <Modal.Description >
                        <Header>Numer sekcji</Header>
                        <Dropdown 
                            className='sectionInput' 
                            placeholder='numer sekcji' 
                            scrolling 
                            clearable 
                            options={sectionptions} 
                            onChange={this.handleChange} 
                            value={this.state.number}
                            selection 
                        />
                        <Header>Student</Header>
                        <Dropdown 
                            className='sectionInput' 
                            placeholder='student' 
                            scrolling 
                            clearable 
                            options={this.state.studentOptions} 
                            onChange={this.handleChangeStudents} 
                            selection 
                        />
                    </Modal.Description>
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={()=>{
                        this.addHandle();
                        this.props.updateData();}}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAddSection;
