<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/AV/PropertyReg/PropertySearchRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:PropertySearchRequest">
						<h3 align="center">
							<span>
								<xsl:text>Входни параметри на търсене на имот</xsl:text>
							</span>
						</h3>
						<table border="0" cellpadding="0" cellspacing="0" class="table-responsive" width="100%">
							<tbody>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Номер на имотна партида</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:PropertyLot">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Стара имотна партида</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:OldPropertyLot">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Кадастрален идентификатор</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:CadastreNumber">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Втори кадастрален идентификатор</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:SecondCadastreNumber">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Идентификатор на служба по вписванията</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:SiteID">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Жилищен комплекс</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:HousingEstate">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Квартал</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:NeighborhoodName">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Улица</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:StreetName">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Номер на улица</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:StreetNumber">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Блок</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:Block">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Вход</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:Entrance">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Етаж</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:Floor">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Апартамент</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:Appartment">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="354">
										<span style="font-style:italic; ">
											<xsl:text>Пощенска кутия</xsl:text>
										</span>
									</td>
									<td style="padding:4px; ">
										<xsl:for-each select="n1:PostBox">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
							</tbody>
						</table>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
