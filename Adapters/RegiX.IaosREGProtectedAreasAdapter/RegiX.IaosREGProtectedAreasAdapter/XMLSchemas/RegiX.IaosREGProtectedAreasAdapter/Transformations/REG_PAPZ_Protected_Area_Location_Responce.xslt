<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/IAOS/REGPapz/ProtectedAreaLocationResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<h2 align="center">
						<span>
							<xsl:text>Справка по местонахождение в Регистър на защитените територии и зони в България</xsl:text>
						</span>
					</h2>
					<table align="center" border="1" width="50%">
						<tbody>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Код на защитената територия</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG_PAPZ_Protected_Area_Location_Response">
									<xsl:for-each select="n1:ProtectedAreaLocation">
										<td>
											<xsl:for-each select="n1:AreaCode">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Наименование на защитената територия</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG_PAPZ_Protected_Area_Location_Response">
									<xsl:for-each select="n1:ProtectedAreaLocation">
										<td>
											<xsl:for-each select="n1:AreaName">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Площ на защитената територия/зона</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG_PAPZ_Protected_Area_Location_Response">
									<xsl:for-each select="n1:ProtectedAreaLocation">
										<td>
											<xsl:for-each select="n1:AreaSize">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Тип на територията</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG_PAPZ_Protected_Area_Location_Response">
									<xsl:for-each select="n1:ProtectedAreaLocation">
										<td>
											<xsl:for-each select="n1:AreaType">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Регионална инспекция по околната среда и водите (РИОСВ)</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG_PAPZ_Protected_Area_Location_Response">
									<xsl:for-each select="n1:ProtectedAreaLocation">
										<td>
											<xsl:for-each select="n1:RIOSV">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
						</tbody>
					</table>
					<br/>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
