import React from 'react'
import { Container, List, Button } from 'semantic-ui-react'

import './DetailList.scss'

const DetailList = (props) => {

    return (
        <div className='detailList'>
            <Container>
                <List divided relaxed>
                    <List.Item>
                        <List.Content floated='right'>
                            {props.visibledetail ? <Button onClick={props.detailsClicked}> Szczegóły </Button> : null}
                            {props.visibledelete ? <Button onClick={props.removeClicked}> Usuń </Button> : null}
                            {props.studentgrade}
                        </List.Content>
                        <List.Content floated='right'>
                            {props.finalgrade}
                        </List.Content>
                        {/* <List.Content floated='left'>
                            { props.id }
                        </List.Content> */}
                        <List.Content floated='left'>
                            {props.date}
                        </List.Content>
                        <List.Content>

                        </List.Content>
                        <List.Content >
                            {props.text}
                            {props.sectionnumber}
                            {props.title}
                            &nbsp;                          
                            {props.number}
                            &nbsp;
                            {props.name}
                            &nbsp;
                            {props.studentname}
                        </List.Content>
                        <List.Content>
                            {props.abreviation}
                        </List.Content>
                        <List.Content floated='left' >
                            &nbsp;
                            {props.variant}
                            &nbsp;
                            {props.subject}
                            &nbsp;
                        </List.Content>
                        <List.Content floated='left'>
                            &nbsp;
                            {props.group}
                            &nbsp;
                            {props.grade}
                            &nbsp;
                        </List.Content>
                        <List.Content floated='left'>
                            {props.section}
                        </List.Content>
                    </List.Item>
                </List>
            </Container>

        </div>

    );
}

export default DetailList;