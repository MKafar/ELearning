import React, { Component } from 'react';
import { Button, Header, Modal, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddGroup.scss';


class ModalAddGroup extends Component {

    state = {
        name: ''
    }

    handleChange = (e) => {
        this.setState({ name: e.target.value })
    }
    addHandle = () => {
        console.log(this.props);
        const inputData = this.state.name;
        const exercise = this.props.selectedSubjectID;
        axios.post('/api/Groups/Create', {
            subjectid: exercise,
            name: inputData
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
            <Modal closeIcon trigger={<Button primary className='addGroupbutton'>Dodaj grupę</Button>} centered={false}>
                <Modal.Header>Dodaj grupę</Modal.Header>
                <Modal.Content >
                    <Modal.Description >
                        <Header>Nazwa grupy</Header>
                        <Input className='groupInput' placeholder='nazwa grupy' onChange={this.handleChange} />
                    </Modal.Description>
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={()=>{
                        this.addHandle();
                        this.props.updateData();}}> Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAddGroup;
