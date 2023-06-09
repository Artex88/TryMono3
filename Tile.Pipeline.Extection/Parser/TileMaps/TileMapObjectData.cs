﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TryMono3.Map.TileMaps
{
    public class TileMapObjectData
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "name")]      
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "x")]
        public double X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public double Y { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public double Width { get; set; }

        [XmlAttribute(AttributeName = "height")]
        public double Height { get; set; }

        [XmlArray(ElementName = "properties")]
        public List<TileMapProperty> Properties { get; set; }

        [XmlElement(ElementName = "polygon", IsNullable = true)]
        public TileMapPolygonData Polygon { get; set; }

       [XmlElement(ElementName = "point" , Type = typeof(object), IsNullable = true)]
        public object Point { get; set; }

    }
}
