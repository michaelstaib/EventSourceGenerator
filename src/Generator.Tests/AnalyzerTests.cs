﻿using System.Linq;
using ChilliCream.Tracing.Generator.Analyzer.Templates;
using ChilliCream.Tracing.Generator.Properties;
using ChilliCream.Tracing.Generator.Templates;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace ChilliCream.Tracing.Generator
{
    public class EventSourceDefinitionVisitorTests
    {

        [Fact]
        public void GetEventSourceDetailsWithNameConstant()
        {
            // arrange
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(Resources.EventSourceWithConstant);

            // act
            EventSourceDefinitionVisitor visitor = new EventSourceDefinitionVisitor();
            visitor.Visit(syntaxTree.GetRoot());

            // assert
            visitor.EventSource.Should().NotBeNull();
            visitor.EventSource.InterfaceName.Should().Be("IMessageEventSource");
            visitor.EventSource.Namespace.Should().Be("EventSources");
            visitor.EventSource.Name.Should().Be("MessageEventSource");
            visitor.EventSource.FileName.Should().Be("MessageEventSource.cs");

            visitor.EventSource.Attribute.HasProperties.Should().BeTrue();
            visitor.EventSource.Attribute.Properties.Should().HaveCount(1);

            AttributePropertyModel attributeProperty = visitor.EventSource.Attribute.Properties.First();
            attributeProperty.Name.Should().Be("Name");
            attributeProperty.Value.Should().Be("Constants.MessageEventSourceName");
        }

        [Fact]
        public void GetEventSourceDetailsWithLiteral()
        {
            // arrange
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(Resources.EventSourceWithLiteral);

            // act
            EventSourceDefinitionVisitor visitor = new EventSourceDefinitionVisitor();
            visitor.Visit(syntaxTree.GetRoot());

            // assert
            visitor.EventSource.Should().NotBeNull();
            visitor.EventSource.InterfaceName.Should().Be("IMessageEventSource");
            visitor.EventSource.Namespace.Should().Be("EventSources");
            visitor.EventSource.Name.Should().Be("MessageEventSource");
            visitor.EventSource.FileName.Should().Be("MessageEventSource.cs");

            visitor.EventSource.Attribute.HasProperties.Should().BeTrue();
            visitor.EventSource.Attribute.Properties.Should().HaveCount(1);

            AttributePropertyModel attributeProperty = visitor.EventSource.Attribute.Properties.First();
            attributeProperty.Name.Should().Be("Name");
            attributeProperty.Value.Should().Be("\"Foo\"");
        }

        [Fact]
        public void GetEventAttribute()
        {
            // arrange
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(Resources.EventSourceWithLiteral);

            // act
            EventSourceDefinitionVisitor visitor = new EventSourceDefinitionVisitor();
            visitor.Visit(syntaxTree.GetRoot());

            // assert
            visitor.EventSource.Events.Should().HaveCount(1);

            EventModel eventModel = visitor.EventSource.Events.First();
            eventModel.Name.Should().Be("MessageSent");
            eventModel.Id.Should().Be(1);

            eventModel.Attribute.HasProperties.Should().BeTrue();
            eventModel.Attribute.Properties.Should().HaveCount(4);

            eventModel.Attribute.Properties[0].Name.Should().BeNullOrEmpty();
            eventModel.Attribute.Properties[0].Value.Should().Be("1");
            eventModel.Attribute.Properties[1].Name.Should().Be("Level");
            eventModel.Attribute.Properties[1].Value.Should().Be("EventLevel.Verbose");
            eventModel.Attribute.Properties[2].Name.Should().Be("Message");
            eventModel.Attribute.Properties[2].Value.Should().Be("\"Sent message {correlationId}/{messageId} to {to}.\"");
            eventModel.Attribute.Properties[3].Name.Should().Be("Version");
            eventModel.Attribute.Properties[3].Value.Should().Be("1");
        }

        [Fact]
        public void GetEventParameters()
        {
            // arrange
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(Resources.EventSourceWithLiteral);

            // act
            EventSourceDefinitionVisitor visitor = new EventSourceDefinitionVisitor();
            visitor.Visit(syntaxTree.GetRoot());

            // assert
            visitor.EventSource.Events.Should().HaveCount(1);

            EventModel eventModel = visitor.EventSource.Events.First();
            eventModel.Name.Should().Be("MessageSent");
            eventModel.Id.Should().Be(1);

            eventModel.HasParameters.Should().BeTrue();
            eventModel.Parameters[0].Name.Should().Be("messageId");
            eventModel.Parameters[0].Type.Should().Be("Guid");
            eventModel.Parameters[1].Name.Should().Be("correlationId");
            eventModel.Parameters[1].Type.Should().Be("Guid");
            eventModel.Parameters[2].Name.Should().Be("messageType");
            eventModel.Parameters[2].Type.Should().Be("string");
            eventModel.Parameters[3].Name.Should().Be("from");
            eventModel.Parameters[3].Type.Should().Be("string");
            eventModel.Parameters[4].Name.Should().Be("to");
            eventModel.Parameters[4].Type.Should().Be("string");
        }
    }
}
