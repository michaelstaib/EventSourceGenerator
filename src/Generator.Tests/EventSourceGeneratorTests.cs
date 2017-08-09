﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;
using ChilliCream.Logging.Generator.EventSourceDefinitions;
using Nustache.Core;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;

namespace ChilliCream.Logging.Generator
{
    public class EventSourceGeneratorTests
    {
        [Fact]
        public void GenerateEventSource()
        {
            // arrange
            SyntaxTree tree = CSharpSyntaxTree.ParseText(EventSourceSamples.SimpleEventSource);
            SyntaxNode simpleEventSource = tree.GetRoot();

            EventSourceDefinitionVisitor visitor = new EventSourceDefinitionVisitor();
            visitor.Visit(simpleEventSource);

            // act
            tree = CSharpSyntaxTree.ParseText(EventSourceSamples.EventSourceTemplate);
            SyntaxNode eventSourceTemplate = tree.GetRoot();

            EventSourceRewriter eventSourceRewriter = new EventSourceRewriter(visitor.EventSourceDefinition);
            SyntaxNode eventSource = eventSourceRewriter.Visit(eventSourceTemplate);

            // assert

        }

        [Fact]
        public void NustacheTest()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = File.ReadAllText(@"C:\Work\EventSourceGenerator\src\Generator\EventSource.json");
            object data = serializer.Deserialize<IDictionary<string, object>>(json);

        }

    }
}
