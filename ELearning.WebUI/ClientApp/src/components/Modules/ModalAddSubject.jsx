import React, { Component } from 'react';
import { Button, Header, Modal, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddSubject.scss';

class ModalAddSubject extends Component {

    state = {
        name: '',
        abreviation: ''
    }
    handleChange = (e) => {
        this.setState({ name: e.target.value })
    }
    handleChangeS = (e) => {
        this.setState({ abreviation: e.target.value })
    }
    addHandle = () => {
        const inputName = this.state.name;
        const inputAbreviation = this.state.abreviation;
        axios.post('/api/Subjects/Create', {
            name: inputName,
            abreviation: inputAbreviation
        })
            .then(response => {
                console.log(response);
                this.props.updateData();
            })
            .catch(error => {
                console.log(error.response);
            })
    }
    render() {



        return (
            <Modal closeIcon trigger={<Button primary >Dodaj przedmiot</Button>} centered={false}>
                <Modal.Header>Dodaj przedmiot</Modal.Header>
                <Modal.Content >
                    <Modal.Description >
                        <Header>Nazwa Laboratorium</Header>
                        <Input className='subjectInput' placeholder='Nazwa laboratorium' onChange={this.handleChange} />
                        <Input className='subjectAInput' placeholder='Skrót' onChange={this.handleChangeS} />
                    </Modal.Description>
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={()=>{
                        this.addHandle();
                        this.props.updateData(); }}> Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAddSubject
